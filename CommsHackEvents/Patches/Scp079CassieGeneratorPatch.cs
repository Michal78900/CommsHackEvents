namespace CommsHackEvents.Patch
{
    using HarmonyLib;
    using Mirror;
    using System;
    using System.Linq;
    using UnityEngine;

    [HarmonyPatch(typeof(Generator079), nameof(Generator079.LateUpdate))]
    public static class Scp079CassieGeneratorPatch
    {
        public static bool Prefix(Generator079 __instance)
        {
			if (CommsHackEvents.Singleton.Config.GeneratorActivated.FileName.Count == 0)
				return true;

			if (Mathf.Abs(__instance._localTime - __instance.remainingPowerup) > 1.3f || Math.Abs(__instance.remainingPowerup) < 0.0001f)
			{
				__instance._localTime = __instance.remainingPowerup;
			}

			if (__instance._prevConn && __instance._tabletAnimCooldown <= 0f && __instance._localTime > 0f && !Generator079.mainGenerator.forcedOvercharge)
			{
				if (NetworkServer.active && __instance.remainingPowerup > 0f)
				{
					__instance.NetworkremainingPowerup = __instance.remainingPowerup - Time.deltaTime;
					if (__instance.remainingPowerup < 0f)
					{
						__instance.NetworkremainingPowerup = 0f;
					}
					__instance._localTime = __instance.remainingPowerup;
				}
				__instance._localTime -= Time.deltaTime;
				if (__instance._localTime < 0f)
				{
					__instance._localTime = 0f;
				}
			}
			else
			{
				if (NetworkServer.active && __instance._prevConn && __instance._localTime <= 0f && __instance.isTabletConnected && !Generator079.mainGenerator.forcedOvercharge)
				{
					byte b = (byte)Enumerable.Count<Generator079>(Generator079.Generators, (Generator079 gen) => gen._localTime <= 0f);
					__instance.NetworkremainingPowerup = 0f;
					__instance._localTime = 0f;
					__instance.EjectTablet();
					__instance.RpcNotify(b);

					if(b == 5)
					{
						Recontainer079.BeginContainment(true);
					}
					Generator079.mainGenerator.NetworktotalVoltage = b;
				}
				if (!__instance._prevConn && NetworkServer.active && __instance._tabletAnimCooldown < 0f && __instance.remainingPowerup < __instance.startDuration - 1f && __instance.remainingPowerup > 0f)
				{
					__instance.NetworkremainingPowerup = __instance.remainingPowerup + Time.deltaTime;
				}
			}
			__instance.localVoltage = 1f - Mathf.InverseLerp(0f, __instance.startDuration, __instance._localTime);
			__instance.CheckTabletConnectionStatus();
			__instance.CheckFinish();
			__instance.Unlock();

			return false;
		}
    }
}
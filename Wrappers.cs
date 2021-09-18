using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Core;

namespace PleaseReColorMyMenu
{
    static class Wrappers
    {
		public static string GetFullName(this GameObject gameObject)
		{
			string name = gameObject.name;
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
				name = gameObject.name + "/" + name;
			}
			return name;
		}
		public static ApiWorld GetWorld() =>
			RoomManager.field_Internal_Static_ApiWorld_0;

		public static ApiWorldInstance GetWorldInstance() =>
			RoomManager.field_Internal_Static_ApiWorldInstance_0;
	}
}

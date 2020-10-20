// © 2020 Joshua Petersen. All rights reserved.
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Method)]
public class ButtonAttribute : Attribute {
	public string Text { get; set; }
	
	public string Tooltip { get; set; }
}
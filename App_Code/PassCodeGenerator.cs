﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PassCodeGenerator
/// </summary>
public class PassCodeGenerator
{
    Random rand = new Random();

    public int GetPassCode()
    {
        return rand.Next(1000000, 9999999);
    }
}
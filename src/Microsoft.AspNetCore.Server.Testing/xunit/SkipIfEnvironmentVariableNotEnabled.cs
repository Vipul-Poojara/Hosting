﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Testing.xunit;

namespace Microsoft.AspNetCore.Server.Testing
{
    /// <summary>
    /// Skip test if a given environment variable is not enabled. To enable set environment variable 
    /// to true for the test process.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SkipIfEnvironmentVariableNotEnabledAttribute : Attribute, ITestCondition
    {
        private readonly string _environmentVariableName;

        public SkipIfEnvironmentVariableNotEnabledAttribute(string environmentVariableName)
        {
            _environmentVariableName = environmentVariableName;
        }

        public bool IsMet
        {
            get
            {
                return string.Compare(Environment.GetEnvironmentVariable(_environmentVariableName), "true", ignoreCase: true) == 0;
            }
        }

        public string SkipReason
        {
            get
            {
                return $"Skipping test. To run this test, set the environment variable {_environmentVariableName}=true.";
            }
        }
    }
}
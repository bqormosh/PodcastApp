﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;


public static class IdentityExtensions
{
    public static string FirstName(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");
        // Test for null to avoid issues during local testing
        return (claim != null) ? claim.Value : string.Empty;
    }
    public static string LastName(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst("LastName");
        // Test for null to avoid issues during local testing
        return (claim != null) ? claim.Value : string.Empty;
    }
}


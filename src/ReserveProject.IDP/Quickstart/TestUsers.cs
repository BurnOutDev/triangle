// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace ReserveProject.IDP
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{SubjectId = "818727", Username = "burnoutdev", Password = "sassless88", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "Irakli Murusidze"),
                    new Claim(JwtClaimTypes.GivenName, "Irakli"),
                    new Claim(JwtClaimTypes.FamilyName, "Murusidze"),
                    new Claim(JwtClaimTypes.Email, "iraklimurusidze@live.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "88421113", Username = "gege", Password = "heisenberg123", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "George Gegeshidze"),
                    new Claim(JwtClaimTypes.GivenName, "George"),
                    new Claim(JwtClaimTypes.FamilyName, "Gegeshidze"),
                    new Claim(JwtClaimTypes.Email, "bfgegesha@yahoo.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "somewhere")
                }
            }
        };
    }
}
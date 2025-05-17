// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace EcommerceApp.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission", "catalog_readPermission"}},
            new ApiResource("resource_discount"){Scopes={"disocunt_fullpermission"}},
            new ApiResource("resource_order"){Scopes={"order_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("catalog_readPermission", "Read permission for Catalog API."),
            new ApiScope("catalog_fullpermission", "Full permission for Catalog API."),
            new ApiScope("disocunt_fullpermission", "Full permission for Discount API."),
            new ApiScope("order_fullpermission", "Full permission for Order API."),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client()
            {
                ClientId="EcommerceAppVisitorId",
                ClientName="EcommerceApp Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("ecommerceSecret".Sha256())},
                AllowedScopes = { "catalog_readPermission" }
            },

            // Manager
            new Client()
            {
                ClientId ="EcommerceAppManagerId",
                ClientName ="EcommerceApp Manager",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("ecommerceSecret".Sha256())},
                AllowedScopes = { "disocunt_fullpermission" }
            },

            // Admin
            new Client()
            {
                ClientId = "EcommerceAppAdminId",
                ClientName = "EcommerceApp Admin",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("ecommerceSecret".Sha256())},
                AllowedScopes = { "catalog_fullpermission", "disocunt_fullpermission","order_fullpermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OpenId,},
                AccessTokenLifetime = 600
            }
        };
    }
}
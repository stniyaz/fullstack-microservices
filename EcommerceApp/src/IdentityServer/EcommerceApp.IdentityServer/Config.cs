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
            new ApiResource("resource_cargo"){Scopes={"cargo_fullpermission"}},
            new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
            new ApiResource("resource_comment"){Scopes={"comment_fullpermission"}},
            new ApiResource("resource_payment"){Scopes={"payment_fullpermission"}},
            new ApiResource("resource_images"){Scopes={"images_fullpermission"}},
            new ApiResource("resource_ocelot"){Scopes={"ocelot_fullpermission"}},
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
            new ApiScope("cargo_fullpermission", "Full permission for Cargo API."),
            new ApiScope("basket_fullpermission", "Full permission for Basket API."),
            new ApiScope("comment_fullpermission", "Full permission for Comment API."),
            new ApiScope("payment_fullpermission", "Full permission for Payment API."),
            new ApiScope("images_fullpermission", "Full permission for Images API."),
            new ApiScope("ocelot_fullpermission", "Full permission for Ocelot API."),
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
                AllowedScopes = { "catalog_readPermission", "disocunt_fullpermission", "ocelot_fullpermission", "images_fullpermission", "catalog_fullpermission" }
            },

            // Manager
            new Client()
            {
                ClientId ="EcommerceAppManagerId",
                ClientName ="EcommerceApp Manager",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("ecommerceSecret".Sha256())},
                AllowedScopes = { "disocunt_fullpermission", "ocelot_fullpermission", "comment_fullpermission", "payment_fullpermission", "images_fullpermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OpenId, }
            },

            // Admin
            new Client()
            {
                ClientId = "EcommerceAppAdminId",
                ClientName = "EcommerceApp Admin",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("ecommerceSecret".Sha256())},
                AllowedScopes = { "catalog_fullpermission", "disocunt_fullpermission","order_fullpermission","cargo_fullpermission","basket_fullpermission","ocelot_fullpermission","comment_fullpermission", "payment_fullpermission","images_fullpermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OpenId,},
                AccessTokenLifetime = 600
            }
        };
    }
}
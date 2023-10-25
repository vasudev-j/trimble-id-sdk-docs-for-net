﻿using TrimbleCloud.Authentication;

/// --- Serial Refresh with PKCE ---
/// Public clients that use Authorization code grant with Proof Key for Code Exchange (PKCE) can use Serial PKCE to refresh their access token. 


IEndpointProvider endpointProvider = OpenIdEndpointProvider.Production;
var tokenProvider = new RefreshableTokenProvider(endpointProvider, "CLIENT_ID")
                                    .WithProofKeyForCodeExchange("OLD_CODE_VERFIER")
                                    .WithRefreshToken("OLD_REFRESH_TOKEN");

var accessToken = await tokenProvider.RetrieveToken();
var refreshToken = await tokenProvider.RetrieveRefreshToken();
var newCodeVerifier = await tokenProvider.RetrieveCodeVerifier();

Console.WriteLine($"Refreshed access_token: {accessToken}, refresh_token: {refreshToken}, code_verifier: {newCodeVerifier}");
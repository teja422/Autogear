(function (){
"use strict";
angular.module("AutoGear",
    [
        "Autogear.Core", // Core functionality
        "Autogear.Services", // Data Services 

        "Autogear.Layout", // Root 
        "Autogear.Login",  // Login Module
        "Autogear.Admin"   // Admin Module
    ]
    );
});
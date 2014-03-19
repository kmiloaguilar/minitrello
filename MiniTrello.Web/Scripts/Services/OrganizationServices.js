﻿'use strict';

angular.module('app.services').factory('OrganizationServices', ['$http', '$window', function ($http, $window) {

    var organization = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:1416";
    var baseUrl = baseLocalUrl;

    organization.getOrganizationsForLoggedUser = function () {
        return $http.get(baseUrl + '/organizations/' + $window.sessionStorage.token);
    };

    return organization;

}]);


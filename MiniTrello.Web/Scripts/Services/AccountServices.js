'use strict';

angular.module('app.services',[]).factory('AccountServices', ['$http', function ($http) {

    var account = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:6474";
    var baseUrl = baseRemoteUrl;

    account.login = function (data) {
        return $http.post(baseUrl + '/login', data);
    };

    account.register = function(data) {
        return $http.post('http://minitrelloapi.apphb.com/register', data);
    };


    return account;

}]);
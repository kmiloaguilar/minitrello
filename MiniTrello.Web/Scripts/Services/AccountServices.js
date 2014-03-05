'use strict';

angular.module('app.services',[]).factory('AccountServices', ['$http', function ($http) {

    var account = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:1416";
    var baseUrl = baseRemoteUrl;

    account.login = function (data) {
        console.log(baseUrl);
        return $http.post(baseUrl + '/login', data);
    };

    account.register = function (model) {
        
        //return $http({
        //    url: baseUrl + '/register',
        //    method: 'POST',
        //    data: model,
        //    headers: { 'Content-Type': 'application/json' }
        //});
        //    .success(function (data, status, headers, config) {
        //    $scope.persons = data; // assign  $scope.persons here as promise is resolved here 
        //}).error(function (data, status, headers, config) {
        //    $scope.status = status;
        //});
        return $http.post(baseUrl + '/register', model);
    };


    return account;

}]);
'use strict';

angular.module('app.services',[]).factory('AccountServices', ['$http', function ($http) {

    var account = {};

    account.login = function (data) {
        return $http.post('http://minitrelloapi.apphb.com/login', data);
    };

    account.getJson = function(reportTemplateId, reportEntityId) {
        return $http.get('htmlTemplate/' + reportTemplateId + '/json/' + reportEntityId);
    };

    return account;

}]);
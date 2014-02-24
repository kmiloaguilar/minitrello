angular.module('app.services').factory('AccountServices', ['$http', function ($http) {

    var addToPresentationFactory = {};

    addToPresentationFactory.saveTopic = function (data) {
        return $http.post('savetopic', data);
    };

    addToPresentationFactory.getJson = function (reportTemplateId, reportEntityId) {
        return $http.get('htmlTemplate/' + reportTemplateId + '/json/' + reportEntityId);
    }

    return addToPresentationFactory;

}]);
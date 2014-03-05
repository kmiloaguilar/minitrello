'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

  

    // Path: /login
    .controller('AccountController', ['$scope', '$location', '$window', 'AccountServices', function ($scope, $location, $window, AccountServices) {

        

        $scope.$root.title = 'AngularJS SPA | Sign In';

        $scope.Email = "";

        $scope.Password = "";

        $scope.FirstName = "";

        $scope.LastName = "";

        $scope.ConfirmPassword = "";

        // TODO: Authorize a user
        $scope.login = function () {
            var model = { Email: $scope.Email, Password: $scope.Password };
            AccountServices
                .login(model)
                .success(function (data, status, headers, config) {
                    $window.sessionStorage.token = data.token;
                    $scope.message = 'Welcome';
                })
                .error(function (data, status, headers, config) {
                  // Erase the token if the user fails to log in
                  delete $window.sessionStorage.token;

                  // Handle login errors here
                  $scope.message = 'Error: Invalid user or password';
              });
            //$location.path('/');
            return false;
        };

    $scope.goToRegister = function() {
        $location.path('/register');
    };
    $scope.goToLogin = function() {
        $location.path('/login');
    };

    $scope.register = function() {
        var model = { Email: $scope.Email, Password: $scope.Password, ConfirmPassword: $scope.ConfirmPassword, FirstName: $scope.FirstName, LastName: $scope.LastName };
        AccountServices
            .register(model)
            .success(function (data, status, headers, config) {
                console.log('data: ' + data);
            })
            .error(function (data, status, headers, config) {
                console.log('data: ' + data);

            });
        return false;
    };

        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);
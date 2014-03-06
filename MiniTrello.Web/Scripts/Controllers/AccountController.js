﻿'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

  

    // Path: /login
    .controller('AccountController', ['$scope', '$location', '$window', 'AccountServices', function ($scope, $location, $window, AccountServices) {

        
        $scope.loginModel = { Email: '', Password: '' };

    $scope.registerModel = { Email: '', Password: '', FirstName: '', LastName: '', ConfirmPassword: '' };
        
        // TODO: Authorize a user
        $scope.login = function () {

            AccountServices
                .login($scope.loginModel)
              .success(function (data, status, headers, config) {
                  console.log(data);
                  $window.sessionStorage.token = data.Token;
                  console.log($window.sessionStorage.token);
              })
              .error(function (data, status, headers, config) {
                // Erase the token if the user fails to log in
                delete $window.sessionStorage.token;

                // Handle login errors here
                $scope.message = 'Error: Invalid user or password';
            });
            //$location.path('/');
        };

    $scope.goToRegister = function() {
        $location.path('/register');
    };
    $scope.goToLogin = function() {
        $location.path('/login');
    };

    $scope.register = function() {
        AccountServices
            .register($scope.registerModel)
            .success(function (data, status, headers, config) {
                console.log(data);
                $scope.goToLogin();
            })
            .error(function (data, status, headers, config) {
                console.log(data);
            });
    };

        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);
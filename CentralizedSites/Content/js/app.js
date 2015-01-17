(function() {
    'use strict';

    var app = angular.module('dezLoungeApp', []);

    app.controller('LoginController', ['$scope', '$http', function($scope, $http) {

        $scope.returnCredentials = function () {

            $http.post('DezApi/verify/', { username: $scope.user, password: $scope.password, email: $scope.email }).
                  success(function (data, status, headers, config) {
                      if (data === true)
                      {
                          $scope.user = '';
                          $scope.password = '';
                          $scope.email = '';

                          alert("Account was successfully verified!");
                      }

                      else {
                          alert("Check input credentials and try again!");
                      }
                  }).
                  error(function (data, status, headers, config) {
                      alert("Unable to verify account...");
                  });
            }
        }]
    );
})()
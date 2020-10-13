app.controller('homeCtrl', function ($scope, $interval, $http, $rootScope, $window) {
    debugger;
    if ($rootScope.loginStatus == false) { $window.location.href = '#!/'; } // Check login and return to login page.

    $scope.message = 'Home Page inside page';
});
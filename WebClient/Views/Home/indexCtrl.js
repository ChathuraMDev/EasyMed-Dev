app.controller('indexCtrl', function ($scope, $interval, $http, $rootScope, $window) {
    $scope.message = 'INDEX Page inside page';

    // Realtime Clock
    $scope.currentTime = new Date().toLocaleTimeString();
    $interval(function () {
        $scope.currentTime = new Date().toLocaleTimeString();
    }, 1000);

    $scope.appLogin = function (txtUser, txtPass) {
        $http({
            method: "POST",
            url: $rootScope.auth_domain + "/Token",            
            data: 'grant_type=password&username=' + txtUser + '&password=' + txtPass,
            responseType: 'json',
            headers: { 'Content-Type': 'application/json' }
        }).then(function mySuccess(response) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + response.data.access_token; // Set Token to the root header

            $http({
                method: "POST",
                url: $rootScope.auth_domain + "/api/Account/ReadUser",
                data: { txtUserName: txtUser },
                responseType: 'json',
                headers: { 'Content-Type': 'application/json' }
            }).then(function mySuccess(userD) {
                $rootScope.userName = userD.data.txtUserName;
                $rootScope.userActualName = userD.data.txtFName;
                $rootScope.loginStatus = userD.data.userAuth;
                $rootScope.userRole = userD.data.chrRole;

                $window.location.href = '#!/Home'; // Loading home page

            }, function myError(userD) {
                $scope.loginMessage = "Error loading user data!";
            });

            
        }, function myError(response) {
                $scope.loginMessage = "User name or password is incorrect!";
        });


        

    }

    $scope.appLogout = function () {
        debugger;
        $rootScope.userName = "";
        $rootScope.userActualName = "";
        $rootScope.loginStatus = false;
        $rootScope.userRole = "";
        $http.defaults.headers.common.Authorization = null;
        $window.location.href = "#!/";
    }



});



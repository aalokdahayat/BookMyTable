
BookMyTableApp.controller('BookMyTableCtrl', function ($scope, $http) {

    $scope.records = [];
    $scope.HotelDetails = [];
    $scope.MenuList = [{}];

    $http({
        url: "http://localhost:61941/api/Hotel/GetRestaurantDetailsList",
        dataType: 'json',
        method: 'Get',
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.records = response.data;
        $scope.records[0].HotelName = $scope.HotelName;
    });

    var OrderDetailsEntities = new Object();
    $scope.HotelDetails = [];
    $scope.HotelId = 1;




    $http({
        url: "http://108.168.203.227/bookmytable/api/Hotel/GetRestaurantMenuCardDetailsList?hotelId=1",
        dataType: 'json',
        method: 'Get',
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {

        $scope.HotelDetails = response.data;

    });
    var totalPrice = 0;
    var Quantity = 0;
    var DisName = "";


    $scope.BookOrderwithDish = function (obj) {
        Quantity = Quantity + 1
        totalPrice = totalPrice + obj.Price;

        $scope.MenuList.push(obj);
        $scope.TotalPrice = totalPrice;


    };

    $scope.BookTable = function (obj) {
        $scope.OrderDetailsEntities = obj;
        window.location.href = "/BookMyTable/DishListingPage";
    };

    //$scope.openFoodpopup = function (data) {
    //    angular.element('#modal1').modal('show');
    //    $scope.HotelDetails = [];
    //    $scope.HotelId = data;

    //    $http({
    //        url: "http://108.168.203.227/bookmytable/api/Hotel/GetRestaurantMenuCardDetailsList?hotelId=" + $scope.HotelId,
    //        dataType: 'json',
    //        method: 'Get',
    //        headers: {
    //            "Content-Type": "application/json"
    //        }
    //    }).then(function (response) {

    //        $scope.HotelDetails = response.data;

    //    });

    //};

    $scope.closeFoodpopup = function () {
        angular.element('#modal1').modal('hide');
    };

    $scope.openFoodPage = function () {



    };

    $scope.BookMytableAndDish = function () {




        OrderDetailsEntities.HotelId = 1;//$scope.HotelId;
        OrderDetailsEntities.DishId = 1;//$scope.DishId;
        OrderDetailsEntities.ToatalAmount = 10;// $scope.ToatalAmount;
        OrderDetailsEntities.ApprovalName = $scope.ApprovalName;
        OrderDetailsEntities.CustomerName = $scope.CustomerName;
        OrderDetailsEntities.Address = $scope.Address;
        OrderDetailsEntities.City = $scope.City;
        OrderDetailsEntities.Country = $scope.Country;
        OrderDetailsEntities.PhoneNumber = $scope.PhoneNumber;
        OrderDetailsEntities.EmailID = $scope.EmailID;
        OrderDetailsEntities.MenuList = $scope.MenuList;





        $http({
            url: "http://localhost:61941/api/Hotel/AddTablesAndOrderBooking",
            dataType: 'json',
            method: 'POST',
            data: OrderDetailsEntities,
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (response) {

            $scope.OrderResponse = response.data;

            alert("Your order has been Place Succesfully  :" + $scope.OrderResponse[0].OrderID);



        });
        // $scope.reset();






    };

});
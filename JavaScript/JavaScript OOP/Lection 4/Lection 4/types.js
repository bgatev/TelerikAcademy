var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Drivers;
(function (Drivers) {
    var BasePerson = (function () {
        function BasePerson(fullName) {
            this._firstName = fullName.substr(0, fullName.indexOf(" "));
            this._lastName = fullName.substring(fullName.indexOf(" ") + 1, fullName.length);
        }
        Object.defineProperty(BasePerson.prototype, "firstName", {
            get: function () {
                return this._firstName;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(BasePerson.prototype, "lastName", {
            get: function () {
                return this._lastName;
            },
            enumerable: true,
            configurable: true
        });

        BasePerson.prototype.greet = function () {
            return "Hello " + this._firstName + " " + this._lastName;
        };
        return BasePerson;
    })();
    Drivers.BasePerson = BasePerson;

    var CarDriver = (function (_super) {
        __extends(CarDriver, _super);
        function CarDriver(name, experience) {
            _super.call(this, name);
            this.yearsExperience = experience;
            this.vehicles = [];
        }
        CarDriver.CurrentLicenseNumber = function () {
            return this.LicenseNumber;
        };

        CarDriver.prototype.addVehicle = function (vehicle) {
            this.vehicles.push(vehicle);
        };

        CarDriver.prototype.removeVehicle = function (vehicle) {
            var index = this.vehicles.indexOf(vehicle);

            this.vehicles[index] = this.vehicles[this.vehicles.length - 1];
            this.vehicles.pop();

            return vehicle;
        };

        CarDriver.prototype.greet = function () {
            return _super.prototype.greet.call(this);
        };
        CarDriver.LicenseNumber = '1234-5678';
        return CarDriver;
    })(BasePerson);
    Drivers.CarDriver = CarDriver;

    var TruckDriver = (function (_super) {
        __extends(TruckDriver, _super);
        function TruckDriver(name, experience) {
            _super.call(this, name);
            this.yearsExperience = experience;
            this.vehicles = [];
        }
        TruckDriver.prototype.addVehicle = function (vehicle) {
            this.vehicles.push(vehicle);
        };

        TruckDriver.prototype.removeVehicle = function (vehicle) {
            var index = this.vehicles.indexOf(vehicle);

            this.vehicles[index] = this.vehicles[this.vehicles.length - 1];
            this.vehicles.pop();

            return vehicle;
        };

        TruckDriver.prototype.greet = function () {
            return _super.prototype.greet.call(this) + " - " + this.yearsExperience + " years trucker";
        };
        TruckDriver.LicenseNumber = '5678 - 1234';
        return TruckDriver;
    })(BasePerson);
    Drivers.TruckDriver = TruckDriver;

    var BusDriver = (function (_super) {
        __extends(BusDriver, _super);
        function BusDriver(name, experience, lineNumber) {
            _super.call(this, name);
            this.yearsExperience = experience;
            this.vehicles = [];
            this._lineNumber = lineNumber;
        }
        Object.defineProperty(BusDriver.prototype, "lineNumber", {
            get: function () {
                return this._lineNumber;
            },
            enumerable: true,
            configurable: true
        });

        BusDriver.prototype.addVehicle = function (vehicle) {
            this.vehicles.push(vehicle);
        };

        BusDriver.prototype.removeVehicle = function (vehicle) {
            var index = this.vehicles.indexOf(vehicle);

            this.vehicles[index] = this.vehicles[this.vehicles.length - 1];
            this.vehicles.pop();

            return vehicle;
        };

        BusDriver.prototype.greet = function () {
            return _super.prototype.greet.call(this) + " - " + this.yearsExperience + " years spent in Sofia City Transport";
        };
        BusDriver.LicenseNumber = '5555 - 2222';
        return BusDriver;
    })(BasePerson);
    Drivers.BusDriver = BusDriver;
})(Drivers || (Drivers = {}));

var MPS;
(function (MPS) {
    var MyVehicles = (function () {
        function MyVehicles(type, model) {
            this._type = type;
            this._model = model;
        }
        Object.defineProperty(MyVehicles.prototype, "type", {
            get: function () {
                return this._type;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(MyVehicles.prototype, "model", {
            get: function () {
                return this._model;
            },
            enumerable: true,
            configurable: true
        });
        return MyVehicles;
    })();
    MPS.MyVehicles = MyVehicles;
})(MPS || (MPS = {}));

var Train = (function () {
    function Train(type) {
        this._type = type;
        this._timeTable = [];
    }
    Object.defineProperty(Train.prototype, "type", {
        get: function () {
            return this._type;
        },
        enumerable: true,
        configurable: true
    });

    Train.prototype.addToTimeTable = function (train) {
        this._timeTable.push(train);
    };

    Train.prototype.getTimeTable = function () {
        return this._timeTable;
    };
    return Train;
})();

var pesho = new Drivers.CarDriver("Pesho Petrov", 7);
console.log(pesho.greet());
console.log(pesho.yearsExperience);
var car1 = new MPS.MyVehicles("VW", "Golf");
var car2 = new MPS.MyVehicles("VW", "Passat");
var car3 = new MPS.MyVehicles("Ford", "Fiesta");
var car4 = new MPS.MyVehicles("Opel", "Corsa");

pesho.addVehicle(car1);
pesho.addVehicle(car2);
pesho.addVehicle(car3);
pesho.addVehicle(car4);

pesho.removeVehicle(car2);

var gosho = new Drivers.TruckDriver("Gosho Golemeca", 13);
var carsLicense = Drivers.CarDriver.CurrentLicenseNumber();
console.log(gosho.greet());

var bak6i6a = new Drivers.BusDriver("6i6o Bak6i6o", 22, 120);
console.log(bak6i6a.greet() + " line " + bak6i6a.lineNumber);

var byrziqVlak = new Train("Fast Train");
//# sourceMappingURL=types.js.map

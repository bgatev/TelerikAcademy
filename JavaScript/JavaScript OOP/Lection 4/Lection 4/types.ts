interface Person {
    firstName: string;
    lastName: string;
} 

interface Driver extends Person {
    yearsExperience: number;
    vehicles: Vehicle[];
    addVehicle(vehicle: Vehicle): void;
    removeVehicle(vehicle: Vehicle): Vehicle;
}

interface Vehicle {
    type: string;
    model: string;
}

module Drivers {
    export class BasePerson implements Person {
        private _firstName: string;
        private _lastName: string;

        constructor(fullName: string) {
            this._firstName = fullName.substr(0, fullName.indexOf(" "));
            this._lastName = fullName.substring(fullName.indexOf(" ") + 1, fullName.length);
        }

        get firstName() {
            return this._firstName;
        }

        get lastName() {
            return this._lastName;
        }

        greet(): string {
            return "Hello " + this._firstName + " " + this._lastName;
        }
    }

    export class CarDriver extends BasePerson implements Driver {
        private static LicenseNumber: string = '1234-5678';
        vehicles: Vehicle[];
        yearsExperience: number;

        constructor(name: string, experience: number) {
            super(name);
            this.yearsExperience = experience;
            this.vehicles = [];
        }

        static CurrentLicenseNumber(): string {
            return this.LicenseNumber;
        }

        addVehicle(vehicle: Vehicle) {
            this.vehicles.push(vehicle);
        }

        removeVehicle(vehicle: Vehicle): Vehicle {
            var index = this.vehicles.indexOf(vehicle);

            this.vehicles[index] = this.vehicles[this.vehicles.length - 1];
            this.vehicles.pop();

            return vehicle;
        }

        greet(): string {
            return super.greet();
        }
    }

    export class TruckDriver extends BasePerson implements Driver {
        private static LicenseNumber: string = '5678 - 1234';
        vehicles: Vehicle[];
        yearsExperience: number;

        constructor(name: string, experience: number) {
            super(name);
            this.yearsExperience = experience;
            this.vehicles = [];
        }

        addVehicle(vehicle: Vehicle) {
            this.vehicles.push(vehicle);
        }

        removeVehicle(vehicle: Vehicle): Vehicle {
            var index = this.vehicles.indexOf(vehicle);

            this.vehicles[index] = this.vehicles[this.vehicles.length - 1];
            this.vehicles.pop();

            return vehicle;
        }

        greet(): string {
            return super.greet() + " - " + this.yearsExperience + " years trucker";
        }
    }

    export class BusDriver extends BasePerson implements Driver {
        private static LicenseNumber: string = '5555 - 2222';
        vehicles: Vehicle[];
        yearsExperience: number;
        _lineNumber: number;

        constructor(name: string, experience: number, lineNumber: number) {
            super(name);
            this.yearsExperience = experience;
            this.vehicles = [];
            this._lineNumber = lineNumber;
        }

        get lineNumber() {
            return this._lineNumber;
        }

        addVehicle(vehicle: Vehicle) {
            this.vehicles.push(vehicle);
        }

        removeVehicle(vehicle: Vehicle): Vehicle {
            var index = this.vehicles.indexOf(vehicle);

            this.vehicles[index] = this.vehicles[this.vehicles.length - 1];
            this.vehicles.pop();

            return vehicle;
        }

        greet(): string {
            return super.greet() + " - " + this.yearsExperience + " years spent in Sofia City Transport";
        }
    } 
}

module MPS {
    export class MyVehicles implements Vehicle {
        private _type: string;
        private _model: string;

        constructor(type: string, model: string) {
            this._type = type;
            this._model = model;
        }

        get type() {
            return this._type;
        }

        get model() {
            return this._model;
        }
    }
}

class Train {
    private _type: string;
    private _timeTable: Train[];

    constructor(type: string) {
        this._type = type;
        this._timeTable = [];
    }

    get type() {
        return this._type;
    }

    addToTimeTable(train:Train) {
        this._timeTable.push(train);
    }

    getTimeTable() {
        return this._timeTable;
    }
}

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

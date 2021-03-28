class Appointment { public int Id { get; set; } Appointment(int Id, string Date) { } };
interface IAppointment { };
record AppointmentRecord();

class AppointmentsStorageClassOnly<T> where T : class { }

AppointmentsStorageClassOnly<int> storageOne = new(); //compile time error - only classes are allowed
AppointmentsStorageClassOnly<Appointment> storageTwo = new();
AppointmentsStorageClassOnly<IAppointment> storageThree = new(); //alloved 
AppointmentsStorageClassOnly<AppointmentRecord> storageFour = new(); //alloved 


abstract class AppointmentBase { };
class VipAppointment : AppointmentBase { }
class RegularAppointment : AppointmentBase { }

class AppointmentsStorageSpecificClassOnly<T> where T : AppointmentBase { } //specific baseclass


AppointmentsStorageSpecificClassOnly<int> storageFive = new(); //compile time error - only classes are allowed
AppointmentsStorageSpecificClassOnly<Appointment> storageSix = new(); // compile time error - only AppoitmentBase classes are allowed
AppointmentsStorageSpecificClassOnly<VipAppointment> storageSeven = new();
AppointmentsStorageSpecificClassOnly<RegularAppointment> storageEight = new();



class AppointmentsStorageStructOnly<T> where T : struct { }

AppointmentsStorageStructOnly<int> storageNine = new();
AppointmentsStorageStructOnly<Appointment> storageTen = new(); //compile time error - only structs are allowed
AppointmentsStorageStructOnly<AppointmentRecord> storageEleven = new(); //compile time error - only structs are allowed



class AppointmentsStorageOnlyNew<T> where T : new() { }

AppointmentsStorageOnlyNew<Appointment> storageTwelve = new(); //compile time error - only parameterless constructors are allowed
AppointmentsStorageOnlyNew<VipAppointment> storageThirteen = new();
AppointmentsStorageOnlyNew<AppointmentBase> storageFourteen = new(); // //compile time error - only non abstracts are allowed
AppointmentsStorageOnlyNew<int> storageFifteen = new(); // //compile time error - only non abstracts are allowed

//compile error , only one class name and several interfaces are allowed
class AppointmentsStorageStructAndClassOnly<T> where T : VipAppointment, VipAppointment, new() { }


/* More about constraints: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters */

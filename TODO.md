List of features to implement
======

Vehicle Checkout 
-----
* Authorization => Student + Admin
* Scan QR code that identifies vehicle 
* Creates initial Trip w/ VehicleID, StartStationID, StartTime, and StudentID.

Vehicle Checkin
-----
* Authorization => Student & Trip.Owner
* Form => EndStation select dropdown 
* Update Trip to include EndStation + EndTime (currentTime) => Save changes to DB

Student Usage History
------
* Authorization => Student Owner + Admin
* List of all trips completed by Student
  * Pagination
  * Filterable by date?
* Summary of all data

Student Dashboard
------
* Authorization => Student
* Summary of current trip (if available)
* * Link to return vehicle
* Campus Transport Map
* Student Usage Summary
* * Statistics / Rank among students
* * Link to full Student Usage History

Administrative Dashboard
-----
* Authorization => Admin
* Summary of current system status
  * Station Availability
  * Number of disabled vehicles
* Notification Display
  * Tickets created for missing or broken items, etc...
* CRUD for Stations + Vehicles + Students that belong to school
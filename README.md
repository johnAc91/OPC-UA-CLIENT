# OPC-UA-CLIENT
OPC UA Client development.


---------------------------------------------------------------------------
---- OPC UA Client V1 -----------------------------------------------------
---------------------------------------------------------------------------

Application type
	Console App

Instructions
	The file 'OpcUaClientV1_Config' must be in the same path than the 'OpcUaClientV1' file.
	By using the 'OpcUaClientV1_Config' file as an xml file, it is possible to configure:
		- Server params:
			· URL
			· Publishing interval
			· Sampling interval
			· Max. queue size
			· End point security enabled/disabled
		- List of nodes
	When the file 'OpcUaClientV1' is executed, the applications acts as an OPC UA Client:
		1. OPC UA Server connection and subscription
		2. Nodes subscription
		3. Data logging
		4. In case of any error connection:
			· Bad keep alive
			· Server disconnected
			· Others
		    The applications closes the current sessions and tries to start a new one every 10 seconds, 		    	    until the server is connected again.
	All server data logged is written in a CSV file.
	All execution information is written in a log file.

Improvements and bugs
	- The .txt files just must be written every X seconds,
	  to avoid the writting errors due to multiple data received.

---------------------------------------------------------------------------
---- OPC UA Client V2 -----------------------------------------------------
---------------------------------------------------------------------------

Application type
	Console App

New funcitonalities
	- The .txt files just are written periodically.

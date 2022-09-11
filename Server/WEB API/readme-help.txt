read this file for all changes

1 - added a new project VHaaSh.Utilities
2 - moved login helper class to this project
3 - added references for this project where this class is reffered
4 - build is success for entire solution
5 - added interface in account folder bll project

6 - added Unity.WebAPI package to API project
7 - added dependency resolver in Unity.Config file

8 - added separate notifications handler in Notifications project
9 - resolved dependecy in UnitiConfig file in API project

10 - removed all not used using namespaces from all project

11 - tested api methods using swagger ui - working fine
12 - enabled api key in swagger so we can pass token to test authorize web api methods

13 - added unit test project 
	-- nunit framework for unit testing
	-- fakeiteasy to create fake objects 

	steps: 
		-- add class library project
		-- install NUnit package - all test attributes
		-- install NUnit3TestAdapter package - to see all test methods 
		-- install FakeItEasy package 
		-- to test api methods we may need to install System.Net.Http & Newtonsoft.Json packages

14. added log4net logging 
reference - https://www.c-sharpcorner.com/article/configure-log4net-with-database-tutorial-for-beginners/


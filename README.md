# beteasy-code-challenge

This is a console app that prints list of horses by price in ascending order

# adapters

New adapters can be plugged in when a new file type comes in. 

In real work, this would be invoking different services either in a loop or based on certain settings. They just have to be plugged in and instantiated automaticallu.

For the sake of this test, I've assumed that I can differentiate the files by their filetypes and used a strategy to choose the implementation of the respective Adapter.

# services and renderers

Services and renderers can be extended to add new services by just implementing the IService and IRenderer interfaces. 

There is no need to modify existing work flow.

# how to run unit tests

To run unit tests, just open the application in visual studio and run them using TestAdapter or a xUnit runner of your choice

# how to run the application

For the sake of this interview, I've made it easier to run by pressing ctrl + F5. The application uses the default files provided
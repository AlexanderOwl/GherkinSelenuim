Feature: Go to the cinema section
	In order to watch movies
	As a user
	I want to have the opportunity to go to the movies page

Feature: Movie titles converge
    To select a movie
    As a user
    I want the names of the films to match in the list of films and on the page of the film

Feature: search for sections of the poster on the site
To have an idea of all the events
As a user
I want to open the page and see sections of the poster

@Afisha1
Scenario: Go to the cinema section
	Given the page is open
	When click on the movie button
	Then find  test

@Afisha2
Scenario: Movie titles converge
	Given the afisha page is open
	When click on the name of movie
	Then find name of movie

@search
Scenario: Search the movie
	Given The afisha page is open
	When Set first movie in the movie list
	When Enter the movie name in search field
	When Click search button
	Then Search movie name equals find movie name

@search
Scenario: Check the adress of cinemas
	Given Open afisha page
	When Click on cinema
	Then Adress is actual
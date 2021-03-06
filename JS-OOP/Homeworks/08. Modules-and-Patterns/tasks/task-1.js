/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/
"use strict";
var solve = function() {
	var currentId = 0;
	function getNextId() {
		currentId += 1;
		return currentId;
	}

	function splitStudentName(name) {
		if(typeof name != 'string') {
			throw new Error("Name is not a string!");
		}

		let names = name.split(' ');

		if(names.length > 2 || !names[0] || !names[1]) {
			throw new Error("Name has incorrect format!");
		}
		let firstName = names[0];
		let lastName = names[1];

		checkSingleNameValidity(firstName);
		checkSingleNameValidity(lastName);

		return {
			firstname: firstName,
			lastname: lastName
		}
	}

	function checkSingleNameValidity(name) {
		const incorrectFormatMessage = "Name has incorrect format!";

		if(name.length === 0) {
			throw new Error(incorrectFormatMessage);

		}

		if(name[0] != name[0].toUpperCase()) {
			throw new Error(incorrectFormatMessage);
		}

		for(let i = 1; i < name.length; i++) {
			if(name[i] != name[i].toLowerCase()) {
				throw new Error(incorrectFormatMessage);
			}

			if(name[i].toLowerCase() === name[i].toUpperCase()) {
				throw new Error(incorrectFormatMessage);
			}
		}
	}

	function validateTitle(title) {
		if(title.length === 0) {
			throw new Error("Titles must be at least 1 character long!")
		}

		if(title[0] === ' ' || title[title.length - 1] === ' ') {
			throw new Error("Titles do not start or end with a space!")
		}

		var match = title.match(/\s\s+/);
		if(match != null) {
			throw new Error("Titles cannot have two or more consecutive spaces!")
		}
	}


	function validateTitles(titles) {
		if(!titles.length || titles.length === 0) {
			throw new Error("No titles have been passed!")
		}

		for(var title of titles) {
			validateTitle(title);
		}
	}

	var Course = {
		init: function(title, presentations) {
			validateTitle(title);
			validateTitles(presentations);

			this._title = title;
			this._presentations = presentations;
			this._students = [];

			return this;
		},
		addStudent: function(name) {
			let names = splitStudentName(name);
			var studentId = getNextId();
			this._students.push(
				{
					firstname: names.firstname,
					lastname: names.lastname,
					id: studentId,
					homeworks: []
				}
			);
			return studentId;
		},

		getAllStudents: function() {
			return this._students;
		},

		submitHomework: function(studentID, homeworkID) {
			let student = this._students.filter(x => x.id === studentID);
			let homeworkIndex = homeworkID - 1;

			if(studentID != parseInt(studentID, 10)
			|| homeworkID != parseInt(homeworkID, 10)) {
				throw new Error("Id must be an integer!");

			}

			if(student.length === 0) {
				throw new Error("No student with such ID!");
			}

			if(homeworkIndex < 0 || this._presentations.length <= homeworkIndex) {
				throw new Error("Invalid homework ID!");
			}

		},
		pushExamResults: function(results) {
			//[{StudentID: ..., score: ...}]
			let filteredResults = [];

			for(let result of results) {

				if(typeof result.score === 'undefined' || isNaN(result.score) || result.score < 0 || result.score != parseInt(result.score)) {
					throw new Error("Score is not a valid number!")
				}

				if(filteredResults.some(x => x.StudentID === result.StudentID)) {
					throw new Error("Duplicate student in exam results!");
				}

				if(isNaN(result.StudentID)) {
					throw new Error("Student ID is not a valid number!")
				}

				if(result.StudentID < 1 || currentId < result.StudentID) {
					throw new Error("Invalid student id! Student not found!");
				}

				filteredResults.push(result);
			}
		},
		getTopStudents: function() {

		}
	};

	return Course;
};


module.exports = solve;
// var course = Object.create(solve);
// console.log(course.init("Valid title", ["valid pres"]));
// console.log(course.addStudent("Pesho Peshov"));
// console.log(course.addStudent("Pesho Peshov"));
// console.log(course.addStudent("Pesho Peshov"));

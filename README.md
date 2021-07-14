Welcome to Refactoring from Anemic Domain Model Towards a Rich One
=====================

This is the source code for my Pluralsight course [Refactoring from Anemic Domain Model Towards a Rich One][L5].

How to Get Started
--------------

There are 2 versions of the source code: Before and After. You can go ahead and look at the After version but I would recommend that you follow the course and do all refactoring steps along with me.

In order to run the application, you need to create a database and change the connection string in the composition root.

[L2]: DBCreationScript.txt
[L3]: DddInPractice.UI/App.xaml.cs
[L1]: http://www.apache.org/licenses/LICENSE-2.0
[L4]: https://www.pluralsight.com/courses/domain-driven-design-in-practice
[L5]: http://www.pluralsight.com/courses/refactoring-anemic-domain-model

====================
Divan's notes
====================

(4.) Decoupling the Domain Model from the Data Contracts

Why?
===

Changes don't break contracts for clients.
Improve security of contracts: Clients can't change fields that they shouldnt.

How?
===

Create Dtos
Seperate the data contracts and the domain models.
Different contracts for lists, inputs and outputs.

(5.) Using Value Objects as Domain Model Building blocks

Why?
===

This makes the model more expressive and encapsulated.
Identify problems faster(during compilation)
More expressive, readable domain model. Makes concepts explicit.
Avoid domain logic duplication. Adhere to DRY principle.
Raise level of abstraction

How?
===

Use the Value Objects as the buildign blocks of the domain model
Fully utilise the type system

Note: You can use the NuGet package CSharpFunctionalExtentions to get the generic Result or ValueObject classes. Or implement your own.
# Availity Interview Questions

## (1) Tell me about your proudest professional achievement. It can be a personal or school project.

Professionally, I've always been fond of a particular project that I undertook while working at Lexis Nexis (where the primary domain for the position was police record-keeping systems). In this case, we had an idea for a visualization system that would plot different types of events against local areas, organized by date, time, frequency, and so son. However, preliminary work was already implemented by an external contractor, who delivered the functionality in the form of no less than fifty separate ASP.Net projects, implementing each of these separate search criteria in the form of its own copy-pasted codebase! Because working with that kind of code was essentially impossible, it was very necessary to refactor it into something more coherent. 

So that began a process of digging into what was already there to find the commonalities, identifying what was missing in terms of functionality, and figuring out the best way to pull all the pieces together into a coherent, extensible system, and then making it deployable to production. all on a fairly short timeline (about a month). It just ended up being a great example of what often happens in the world of software engineering, where you've got something partially-implemented in a way that leaves much to be desired, and (if you're lucky) you've got the prerogative to analyze it, fix it, and then make it work even better.


## (2) Tell me about your proudest professional achievement. It can be a personal or school project.

One book I've read recently that was great (and also fairly short!)  was [Concurrency in C# Cookbook: Asynchronous, Parallel, and Multithreaded Programming] (https://www.amazon.com/Concurrency-Cookbook-Asynchronous-Multithreaded-Programming/dp/1449367569) by Stephen Cleary (who also happens to have a lot of great online content about asynchronous programming!). 

Writing asynchronous code and asynchronous systems is one of the hardest topics in the wide world of software development, occurring frequently in UI-rich applications or in high-performance back-end code. This particular book does two things very well: (1) it provides a bit of a history lesson on how asynchronous code was handled along the timeline of the .Net development stack, and (2) does some great compare-and-contrast not only of the newest approaches to asynchronous code (the Task library, Rx.Net, and Dataflow blocks). It's also got a bunch of extremely useful and practical tips for things like converting older approaches to newer approaches with a minimal rewriting of behavior. So to the extent that it provides some great theory and general guidance, the tips for dealing with common (but difficult!) real-world problems is where the book really gives some great value. And in ways that are heavily transferrable to the world of Web development with Promises and RxJs!

## (3) If you were to describe to a 7-year old what Availity does, what would you say?

Imagine you're an astronaut, and while you're exploring the vast reaches of space, you meet aliens! These are very pleasant aliens, and you quickly become good friends. They agree to build you a better spaceship! But building a spaceship is no small task, and a lot of very careful thought and planning goes into making a spaceship that's just right for you. And while these aliens are very smart and very advanced in the art of building spaceships, there are still some things they just can't do.

That's where Availity would help you work with these smart aliens to make the best possible spaceship! Even though aliens speak a different language and certainly are shaped differently than humans, Availity would let you tell the aliens everything they need to know to make your great spaceship, and would make sure that you're both on the same page, so that you don't end up with a spaceship designed for elephants for houseflies instead of for human beings.

## (4) See attached folder.

## (5) See attached folder.

## (6) See attached folder.

## (7a)

SELECT CONCAT(CUST.FirstName, ' ', CUST.LastName) 
FROM Customers AS CUST 
WHERE CUST.LastName LIKE 'S%'
ORDER BY CUST.LastName DESC

## (7b)

SELECT C.CustID, CONCAT(C.FirstName, ' ', C.LastName) AS Name, SUM(OL.Cost * OL.Quantity) AS TotalOrderCost
	FROM Customers AS C 
	JOIN [dbo].[Order] AS O ON O.CustomerID = C.CustID
	LEFT JOIN [dbo].[OrderLine] AS OL ON OL.OrdID = O.OrderID
WHERE O.OrderDate > Dateadd(Month, Datediff(Month, 0, DATEADD(m, -6, current_timestamp)), 0)
GROUP BY C.CustID, C.FirstName, C.LastName

## (7c)

SELECT C.CustID, CONCAT(C.FirstName, ' ', C.LastName) AS Name, SUM(OL.Cost * OL.Quantity) AS TotalOrderCost
FROM Customers AS C 
	JOIN [dbo].[Order] AS O ON O.CustomerID = C.CustID
	LEFT JOIN [dbo].[OrderLine] AS OL ON OL.OrdID = O.OrderID
WHERE O.OrderDate > Dateadd(Month, Datediff(Month, 0, DATEADD(m, -6, current_timestamp)), 0)
GROUP BY C.CustID, C.FirstName, C.LastName
HAVING SUM(OL.Cost * OL.Quantity) > 100 AND SUM(OL.Cost * OL.Quantity) < 500
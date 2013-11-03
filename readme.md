### Purpose
The Equalidator checks if two objects are equal - without them implementing any special interface, virtual methods, or attributes.

Equalidator is supposed to help you make your unit tests easier when working with custom data types.

### Usage
Use the Equalidator to compare objects and graphs of objects of any type for equality. Objects do not need to implement their own class specific _Equals()_ function. It´s as simple as:

	MyObjectNetwork a, b;
	...
	Equalidator.AreEqual(a, b);

If the object graphs are not equal an exception is thrown.

Equality is tested by comparing object field values - even private ones in base classes. The Equalidator uses reflection to crawl the object graph and collect all values.

See the usage demo tests in the source code for more examples.
# complete-api-testing
Discover the different ways of testing to deliver a reliable API

## Testing pyramid
In a good devops story it is important to respect the testing pyramid. If you search google for a testing pyramid, you will come up with many examples. Simply explained, the goal is to run as many tests as possible in the shortest possible time, to make sure we have stable software. The fastest tests are at the bottom of the pyramid and should also contain the most tests. The slowest tests are at the top of the pyramid (eg manual testing) and should only be a small subset of the whole.

Within this project we use 4 methods of testing. We start at the bottom of the pyramid and we go up one layer at a time.

### Unit testing
With unit tests we test the smallest piece of code that can be logically isolated in a system. Dependencies are mocked. 
Most of a project should be covered with unit testing.

### Integration testing (in memory)
To avoid confusion, let us first explain what we mean with integration testing within this project.
The tests will boot the api in memory and then send http requests to the in-memory api.
All external dependencies (eg external API's) are mocked.

While unit tests only test an isolated piece of code, integration tests allow us to test an entire API call and ensure that all isolated pieces of code work well together.

These tests are slower than unit tests. Think about whether we really need an integration test for a certain functionality.

### Contract testing

Contract testing ensures that the contract is respected between a consumer and a provider. 
The consumer concludes a pact (= agreement about a contract) and the provider carries out tests to check whether the pact has not been broken.
These tests are executed on a hosted API, so they are slow to execute and can be potentially be flaky. 
Ask the question here whether you should provide contract testing for each API call.

### End to end Testing

With end to end testing we do basically the same things as the in-memory integration tests, except that we run the tests on a hosted API.
Like contract testing, these tests are also slow to perform and can be potentially be flaky.
Limit what you include within end to end testing.

## Examples

- I want to test if my API returns a HTTP 400 (BAD REQUEST) if a parameter is invalid. -> Unit tests on the request validator
- I want to test if a service runs correctly -> Unit tests on the service
- I want to test if an object is stored in my database, after triggering a POST call -> In-memory integration tests
- I want to test if I didn't break the API contract for one of my consumers with new API changes -> Contract testing
- I want to test if an object is stored in my database, after triggering a POST call, knowing I have external dependencies and this is mission-critical functionality -> End to end testing

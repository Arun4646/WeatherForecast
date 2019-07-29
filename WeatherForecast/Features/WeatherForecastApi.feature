Feature: WeatherForecastApi

@mytag
Scenario: A Happy Holiday maker
Given I like to holiday in Sydney
When I look up the weather forecast at 'Sydney' in 'au'
Then I receive the weather forecast
And I only like to holiday on 'Thursday'
And the temperature is warmer than '10' degrees

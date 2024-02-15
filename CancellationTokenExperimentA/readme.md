# Demonstration of CancellationToken Behavior

## Testing locally
- Open the url https://localhost:7110/weatherforecast
	- observe the 5 second wait before returning a result and writing a log line
- Close your browser tab or refresh the page before the result is returned to cause the cancellationToken to trigger and write an error log line and return null

## Testing remotely
- Just update `launchSettings.json`:
	- field `applicationUrl` needs to be updated from locahost to your network url
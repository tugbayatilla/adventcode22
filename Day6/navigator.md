# Goals (WIP 3)

- read "datastream buffer" (single line string) and find the marker
- Rules for finding marker
  - [x] Need at least 4 chars to identify the marker
  - [x] marker checks always most recent(last) 4 chars to analyse
  - [ ] most recent 4 chars should not contain same char to be able to become a marker
  - [ ] marker shows the total number of processed chars in the buffer when it is found

# Smells (WIP 3)

- FindMarker method
  - is static
  - returns a value instead of exception

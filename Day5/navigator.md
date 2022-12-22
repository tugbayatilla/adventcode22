# Goals

- define multiple stacks
- add crates to multiple stacks
- move one crate from one stack to another

# Smells

- Cargo class
    - AddStack returns always 1
    - GetStackById never uses stackId parameter
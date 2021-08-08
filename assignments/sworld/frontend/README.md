# Assignment description

Your task is to render a tree of objects:

- Please exercise 2 possible solutions: iterative and recursive.
- **Angular 8 framework must be used**
- **Use SASS to write css styles.**
- Code should be covered with tests
- Code should be modular (not one file!)
- Should be written in OOP
- User should be able to add/edit/delete child objects anywhere in the tree
- User should be able to add subchildren infinitely
- It should be possible to store the state in local storage.
- It should be possible to read the state from local storage
- Project should be delivered via github or any other public git repository
- **TWS Bootstrap usage in UI is a must**
- **In case any of the requirements are not fulfilled, please specify why**

Example of the structure
```
├── Element #1
├── Element #2
└── Element #3
    ├── Child #1 of element #3
    │   ├── Subchild
    │   ├── Another subchild
    │   ├── Another subchild
    │   └── Last subchild
    ├── Child #2 of element #3
    │   ├── Subchild
    │   ├── Subchild
    │   ├── Subchild
    │   └── Subchild
    └── Child #3 of element #3
        ├── Subchild
        └── Subchild
```
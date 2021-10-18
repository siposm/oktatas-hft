# Read me

Initialization template can be found here for the BlogSystem: https://github.com/siposm/hft-unit-init

Additional notes:
- 1st example: calculator
- 2nd example: logic (without any repo or data layer!)
  - in this case the tested methods usually CRUD operations, which should NOT be tested! we accept the fact that a CRUD operation (read OR write) can be executed successfully!
- 3rd example: BlogSystem with all the layers (like in the project work)
  - the `.mdf` and `.ldf` files can be found as a separate `.zip`, the contents should be copied to the Data layer's root (`BlogSystem/BlogSystem.Data`)

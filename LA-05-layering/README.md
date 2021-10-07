# Attention!

The full example can be downloaded with the `.mdf` and `.ldf` files can be downloaded from [here](http://users.nik.uni-obuda.hu/siposm/lectures/HFT/layering.zip) az one zip.

The base for the lab exercise can be downloaded from here (https://github.com/siposm/hft-layering-init). Note that the solution's name a little different `BlogSystem` vs `Blogging`, but apart from that everything is the same. The steps below needed to be made in order to build up the full application.

#### Steps:

1. create `BlogSystem.Data` layer with `.mdf` `.ldf` files (already seen in the previous lesson)
1. create `BlogSystem.UI` layer (Console Application) and add small test to make sure if DB works correctly
1. add following layers / projects as class libraries
    - BlogSystem.Repository
    - BlogSystem.Logic
    - BlogSystem.Tests
1. `BlogSystem.Repository` layer
    - add reference to data layer
    - create interfaces and classes
1. `BlogSystem.Logic` layer
    - add reference to data + repo
    - create interfaces and classes
1. `BlogSystem.UI` layer
    - add reference to logic and repo
    - write codes to use logic's functionalities

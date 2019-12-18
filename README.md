# Quantum-Fluctuation

### A Brief Introduction to Quantum Mechanics (QM)

Quantum mechanics is one of the most important pillars not only in modern physics but in all of science. It is the science of the really small. It details the nature and interactions of sub-atomic particles such as protons and neutrons and even the more elementary particles such as quarks (the constituents of protons and neutrons). These particles (along with others) make up all the matter and energy we are familiar with in the universe. This has a simple yet important implication; quantum mechanics is a gateway into the true understanding of reality.


### The Weirdness of Quantum Mechanics

Despite QM being the description of the fundamental nature of reality, it comes with some profound implications. QM has been criticised by many (including Albert Einstein!) as being too "spooky". The feature of QM that I will focus on here is known as quantum fluctuation. QM tells us that fluctuations in quantum fields can result in two particles (one matter and one anti-matter) popping into existence out of nothing! These particles quickly rejoin and annihilate.


### Goal of This Project

The goal of this project is to create a visualisation of quantum fluctuations. QM tells us that empty space is not in fact empty. It's actually a bubbling bath of matter particles and their anti-mater counterparts popping in and out of existence. I aim to create a visualisation of this using the unity game engine.


### What Will it Look Like?

A rough idea of what the project will look like can be seen in [this video at 3:00 minutes.](https://youtu.be/_DXHrp6-LZI?t=163) However, instead of simple particles appearing randomly throughout the screen I plan on showing the incessant creation and annihilation of the matter and anti-matter particles along with the procedurally generated quantum foam.


### Conclusion

Overall I am very excited to get started on this project for two main reasons. Firstly, I am excited to see what I can learn from this project about using the Unity game engine. But secondly and equally as important, I have always had a huge interest in physics and game development and I am very happy to have an opportunity to unify these two passions of mine.


## For Grading

### How The Goal Was Achieved

The goal of this project was to develop an procedural generation system to demonstrate the qualities of quantum fluctuation.
The scene consists of a mesh that was created in code, whereby the y values of the vertices are randomly generated using Perlin noise. The mesh itself is created procedurally so that the players camera never gets close to the edge. This is done by time stamping each generated mesh and regularly checking if the player goes too close to the edge. If the player approaches the edge a new mesh is generated in front and the old one is removed from behind.

The particles are a prefab that gets substantiated by an empty game object (that operates as the spawner). The particles are attached via a spring joint and once they are spawned, an impulse force is applied in the opposite direction of the spring joint.

### What am I Proud of

Most proud of the particles, the way the system demonstrates their interactions. I like the use of the perlin field to calculate which parts of the quantum field are most disturbed. Wherever the field is most disturbed that's where youd find the most fluctuations. This is more realistic than having the fluctuations evenly spread out across the field. I also like the fact that the colours are opposite each other.

### What Resources Were Useful

The most useful resource for this project was the unity docs. [This](https://youtu.be/dycHQFEz8VI) was a helpful videos for generating infinite terrain.

### Video

[![Youtube video](http://img.youtube.com/vi/Lxu5-aISQmE&feature/0.jpg)](http://www.youtube.com/watch?v=Lxu5-aISQmE&feature)
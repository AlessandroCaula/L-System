*************************************************************************************************
L-System
*************************************************************************************************
This program implements some of the L-Systems discussed in "Lecture Notes in Biomathematics" by Przemyslaw Prusinkiewcz and James Hanan. A brief description of an L-System will be presented here but for a more complete description the user should consult the literature.

A string of characters (symbols) is rewritten on each iteration according to some replacement rules. Consider an initial string (axiom)
F+F+F+F
and a rewriting rule: 
F --> F+F-F-FF+F+F-F
After one iteration the following string would result:
F+F-F-FF+F+F-F + F+F-F-FF+F+F-F + F+F-F-FF+F+F-F + F+F-F-FF+F+F-F

Some symbols are now given a graphical meaning, for example, F means move forward drawing a line, + means turn right by some predefined angle (90 degrees in this case), - means turn left.
Using these symbols the initial string F+F+F+F is just a rectangle (ø = 90). The replacement rule F --> F+F-F-FF+F+F-F replaces each forward movement by the following figure:
    __
 __|  |   __
      |__|

The following characters have a geometric interpretation.
F -> Move forward by line length drawing a line.
+ -> Turn left by turning angle
- -> Turn right by turning angle

!!!!!!! To launch the program, download the entire L-SystemControl folder. !!!!!!!!!!       
!!!!!!! The executable is in: L-SystemControl\bin\Debug\L-SystemControl.exe !!!!!!!!!

For more documentation:
http://paulbourke.net/fractals/lsys/

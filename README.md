*************************************************************************************************
# L-System
*************************************************************************************************
This program implements some of the L-Systems discussed in "Lecture Notes in Biomathematics" by Przemyslaw Prusinkiewcz and James Hanan. A brief description of an L-System will be presented here but for a more complete description the user should consult the literature.

A string of characters (symbols) is rewritten on each iteration according to some replacement rules.   
- Consider an initial string (<strong>axiom</strong>): F+F+F+F   
- A <strong>rewriting rule</strong>: F &rarr; F+F-F-FF+F+F-F

After one iteration the following string would result:  
F+F-F-FF+F+F-F + F+F-F-FF+F+F-F + F+F-F-FF+F+F-F + F+F-F-FF+F+F-F

Some symbols are now given a graphical meaning, for example, F means move forward drawing a line, &plus; means turn right by some predefined angle (90 degrees in this case), &minus; means turn left.      
Using these symbols the initial string F+F+F+F is just a rectangle (ø = 90). The replacement rule F &rarr; F+F-F-FF+F+F-F replaces each forward movement by the following figure:
 
```
    __       
 __|  |   __
      |__|
```


The following characters have a geometric interpretation.
- F &rarr; Move forward by line length drawing a line.
- &plus; &rarr; Turn left by turning angle
- &minus; &rarr; Turn right by turning angle

<br>

Examples
---

<br>

Axiom = F   
F &rarr; FF+[+F-F-F]-[-F+F+F]   
angle = 20
<div style='display:flex; justify-content:left;'>
    <img src='assets\images\L-system_1.gif'>
</div>

---

<br>

Axiom = F+F+F+F   
F &rarr; F+FF++F+F   
angle = 90 
<div style='display:flex; justify-content:left;'>
    <img src='assets\images\L-system_2.gif'>
</div>

---

<br>


axiom = F+F+F+F   
F -> FF+F+F+F+F+F-F   
angle = 90   
<div style='display:flex; justify-content:left;'>
    <img src='assets\images\L-system_3.gif'>
</div>

<br>

For more documentation: http://paulbourke.net/fractals/lsys/

from graphics import * 
import random
import time

# --- main ---

win = GraphWin("My Window",800,800)
win.setBackground(color_rgb(0,0,0))

pt = Point(250, 250)
pt.setOutline(color_rgb(255,255,0))
pt.draw(win)

while True:
    if win.checkMouse():
        break
    dx = random.randint(-10, 10)
    dy = random.randint(-10, 10)
    pt.move(dx, dy)
    time.sleep(0.1)

win.close()
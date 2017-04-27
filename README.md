# tightsnapper
TightSnapper provides the ability to take snapshots or record a VNC Viewer session. TightSnapper has features such as the ability
to change snapshot intervals, duration of continuous snapshots and compression on output jpegs. 

Requires:
.Net Framework v4 minimum.


Todo:
--
1.) Directly take snapshots of the VNC Server session, rather than taking snapshots of a window on a local VNC Viewer session.

2.) Allow for multiple viewers with different file output naming conventions for each client.

3.) Change PrintWindow method to allow for capturing of a session while the viewer is minimized.

Bugs:
--
- VNC Viewer window must be open in order to capture screenshots of the session. If the window is ever minimized while performing a capture, the screenshot will only show the control buttons of the window. The window may be 'hidden', i.e visible but off screen and it will still work properly.
--

![User Interface](https://github.com/mrnr1/tightsnapper/blob/master/Screenshot.png)

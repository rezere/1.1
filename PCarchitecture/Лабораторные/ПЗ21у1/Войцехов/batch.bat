mkdir batch\Visible
mkdir batch\NotVisible
attrib +h "batch/NotVisible"
xcopy /?>"batch/Visible/copyhelp.txt"
xcopy batch\Visible\copyhelp.txt batch\NotVisible\copied_copyhelp.txt


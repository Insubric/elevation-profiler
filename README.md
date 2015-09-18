Description
-----------
**Elevation profiler** (see Krebs et al. 2015) is an open source GIS tool designed to work with ArcGIS that automatically calculates transverse or longitudinal elevation profiles of different lengths starting from a digital elevation model (e.g. high resolution Lidar DEM) and a shapefile of points (i.e. the midpoints of the profile segments). The calculated profiles are then saved in comma-separated tabular data files (.csv).

Definitions
----------------------
An elevation profile represents the intersection of a vertical plane with the DEM surface. In particular, the Transverse Elevation Profile (TEP) is defined as a two-dimensional cross sectional profile in the vertical plane oriented perpendicularly to the maximum gradient direction, while the Longitudinal Elevation Profile (LEP) is a profile following the line of maximum slope (see Krebs et al. 2015). These elevation profiles provide a real-scale visualization of the relief of the terrain and offer multiple possibilities for analyzing the topography and the terrain curvature around spatial points.

Versions and requirements
-------------------------
At the moment (September 2015), the tool is available in the following two versions:

1.	For ArcGIS 9.3 (and previous). Originally the Elevation profiler was conceived as a VBA (Visual Basic for Applications) macro ready to be added and run from the visual basic editor in ArcGIS 9.3 and previous versions. This first version is composed by a form interface and five modules.
2.	For ArcGIS 10.0 (and higher). Starting at version 10, VBA is no longer supported in ArcGIS and a special license is required to open the VBA editor and to use any macro or customization built with this code. To overcome this problem, the Elevation profiler GIS tool has been migrated to Visual Basic .NET (VB.NET) and is now provided as an add-in for ArcGIS.

Interface
---------
Through a simple form interface the user can choose some parameters that define the characteristics of the required profiles. At first the user has to decide which type of profile (TEP or LEP) he want to obtain. Then with the *minimum length*, the *maximum length* and the *interval* the user decides the list of increasing lengths of the profiles he wants to obtain for each point or site. The *resolution* defines the number of points that will be created on the profile segments. For instance with a resolution of 1 meter a 100 meters long elevation profile will be composed by 101 segment points. The resolution has to be set by considering the cell size, or spatial resolution, of the DEM raster.

How it works
------------
Starting from the point features defined in the shapefile, and retaining these features as centers of the profile segments, the tool builds an elevation profile around every point. The orientation of the TEP is given by the pairs of opposed endpoints that minimize the absolute difference of altitude when projected on the DEM. On the contrary, the pairs of opposed endpoints maximizing the absolute difference of altitude defines the orientation of the LEP. For every segment point the Elevation profiler extracts the value of the altitude from the DEM by applying a bilinear interpolation. At the end the GIS tool saves all the results in various types of comma-separated tabular data files (.csv). In particular the elevation profiles for every site are saved as columns in a table with a row for every segment point containing the difference of altitude as regards the elevation of the site. The orientation of every profile segment and the spatial coordinates (X e Y) for all segment points are saved in two additional .csv tables.

References
----------

* Krebs, Patrik; Stocker, Markus; Pezzatti, Gianni Boris; Conedera, Marco; 2015. An alternative approach to transverse and profile terrain curvature. *International Journal of Geographical Information Science*, 29(5), pp. 643-666.
* Patrik Krebs (patrik.krebs@wsl.ch) and Gianni Boris Pezzatti (boris.pezzatti@wsl.ch): Insubric Ecosystems Group, Swiss Federal Research Institute WSL, Bellinzona, Switzerland.
* Markus Stocker (markus.stocker@gmail.com): Research Group of Environmental Informatics, University of Eastern Finland, Kuopio, Finland.

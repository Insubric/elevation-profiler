Short description
-----------------
**Elevation profiler** is a GIS tool designed to work with ArcGIS that automatically calculates transverse or longitudinal elevation profiles of different lengths starting from a digital elevation model (e.g. high resolution Lidar DEM) and a shapefile of points (i.e. the midpoints of the profile segments). The calculated profiles are then saved in comma-separated tabular data files (.csv).

Additional definitions
----------------------
An elevation profile represents the intersection of a vertical plane with the DEM surface. In particular, the Transverse Elevation Profile (TEP) is defined as a two-dimensional cross sectional profile in the vertical plane oriented perpendicularly to the maximum gradient direction, while the Longitudinal Elevation Profile (LEP) is a profile following the line of maximum slope. These elevation profiles provide a real-scale visualization of the relief of the terrain and offer multiple possibilities for analyzing the topography and the terrain curvature around spatial points.

Versions and requirements
-------------------------
At the moment (september 2015), the tool is available in the following two versions:

1.	For ArcGIS 9.3 (and previous). Originally the Elevation profiler was conceived as a VBA (Visual Basic for Applications) macro ready to be added and run from the visual basic editor in ArcGIS 9.3 and previous versions. This first version is composed by a form interface and five modules.



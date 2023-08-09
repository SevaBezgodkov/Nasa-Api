namespace NasaAPI
{
    using System;
    using System.Collections.Generic;

    public class EstimatedDiameter
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class Meters
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class Miles
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class Feet
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class EstimatedDiameter2
    {
        public EstimatedDiameter kilometers { get; set; }
        public Meters meters { get; set; }
        public Miles miles { get; set; }
        public Feet feet { get; set; }
    }

    public class RelativeVelocity
    {
        public string kilometers_per_second { get; set; }
        public string kilometers_per_hour { get; set; }
        public string miles_per_hour { get; set; }
    }

    public class MissDistance
    {
        public string astronomical { get; set; }
        public string lunar { get; set; }
        public string kilometers { get; set; }
        public string miles { get; set; }
    }

    public class CloseApproachDatum
    {
        public string close_approach_date { get; set; }
        public string close_approach_date_full { get; set; }
        public long epoch_date_close_approach { get; set; }
        public RelativeVelocity relative_velocity { get; set; }
        public MissDistance miss_distance { get; set; }
        public string orbiting_body { get; set; }
    }

    public class Link
    {
        public string self { get; set; }
    }

    public class NearEarthObject
    {
        public string id { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public string name { get; set; }
        public List<CloseApproachDatum> close_approach_data { get; set; }
        public bool is_sentry_object { get; set; }
    }

    public class Root
    {
        public string startDate { get; set; }
        public Links links { get; set; }
        public Dictionary<string, List<NearEarthObject>> near_earth_objects { get; set; }
    }

    public class Links
    {
        public string next { get; set; }
        public string prev { get; set; }
        public string self { get; set; }
    }
}

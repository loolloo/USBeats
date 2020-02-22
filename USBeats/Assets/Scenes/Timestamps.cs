using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timestamps : MonoBehaviour
{
	public Dictionary<uint, List<float>> data;

    // Start is called before the first frame update
    void Start()
    {
        data = new Dictionary<uint, List<float>>();
    }

    // Update is called once per frame
    void Update()
    {
    }

	// Add a timestamp
    void addTimestamp(uint chord, float stamp)
    {
		data[chord].Add(stamp);
	}

	// Write the recorded timestamps to a file
	void writeTimestampToFile(string filename)
	{
		uint nbchords = (uint)data.Count;
		
		// Open the stream
		using (System.IO.StreamWriter file =
			new System.IO.StreamWriter(filename)) {
			// Number of active chords
			file.WriteLine(nbchords.ToString());
			
			// iterate over the chords
			for (uint chord = 1; chord < nbchords + 1; chord++) {

				// Iterate over the stamps
				foreach (float stamp in data[chord]) {
					file.WriteLine(stamp.ToString());
				}
				
				// End of chord
				file.WriteLine("EOC");
			}
		}
	}

	// Read the timestamps from a file
	void readTimestampsFromFile(string filename)
	{
		using (System.IO.StreamReader file =
			new System.IO.StreamReader(filename)) {
			string line = file.ReadLine();
			if (line != null) {
				// Number of chords
				uint nbchords = uint.Parse(line);

				for (uint chord = 1; chord < nbchords + 1; chord++) {
					while ((line = file.ReadLine()) != null && line != "EOC") {
						addTimestamp(chord, float.Parse(line));
					}
				}
			}
		}
	}
}

$apis = @{ 
	{
		remove-item ./src/Apideck.$($h.Name) -recurse -force
	}
	New-Item ./docs/$($h.Name) -ItemType Directory -Force
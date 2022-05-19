all:
	@echo "Build this project in Visual Studio."

clean:
	rm -rf  SetupAnyCPU/{Debug,Release} \
            src/{bin,obj} \
            .vs

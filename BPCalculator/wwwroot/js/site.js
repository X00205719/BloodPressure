const ctx = document.getElementById('myChart');
const systolic = document.getElementById("BP_Systolic").value;
const diastolic = document.getElementById("BP_Diastolic").value;

const bgLayer = {
    id: 'bgLayer',
    beforeDatasetsDraw: ((chart, args, plugin) => {
        const {
            ctx,
            chartArea: { top, bottom, left, right, width, height },
            scales: { x, y }
        } = chart;

        const bpStages = [
            {
                name: 'Low',
                xEnd: 59,
                yEnd: 89,
                color: '#E4C1F9'
            },
            {
                name: 'Ideal',
                xEnd: 79,
                yEnd: 119,
                color: '#68A691'
            },
            {
                name: 'Pre-High',
                xEnd: 89,
                yEnd: 139,
                color: '#C7EF00'
            },
            {
                name: 'High',
                xEnd: x.max,
                yEnd: y.max,
                color: '#FF5E5B'
            }
        ];

        bpStages.forEach((stage, index) => {
            ctx.beginPath();
            ctx.globalCompositeOperation = 'destination-over';
            ctx.fillStyle = stage.color
            ctx.moveTo(x.getPixelForValue(40), y.getPixelForValue(70));
            ctx.lineTo(x.getPixelForValue(stage.xEnd), y.getPixelForValue(70));
            ctx.lineTo(x.getPixelForValue(stage.xEnd), y.getPixelForValue(stage.yEnd));
            ctx.lineTo(x.getPixelForValue(40), y.getPixelForValue(stage.yEnd));
            ctx.closePath();
            ctx.fill();
            ctx.restore();
            ctx.globalCompositeOperation = 'source-over';
        });
    })
};

new Chart(ctx, {
    type: 'scatter',
    data: {
        datasets: [{
            label: 'Result',
            data: [{
                x: diastolic,
                y: systolic
            }],
            borderWidth: 2,
            borderColor: '#FFF',
            backgroundColor: '#007FFF'
        }]
    },
    plugins: [bgLayer],
    options: {
        scales: {
            x: {
                min: 40,
                max: 100,
                title: {
                    display: true,
                    text: 'Diastolic'
                }
            },
            y: {
                min: 70,
                max: 190,
                title: {
                    display: true,
                    text: 'Systolic'
                }
            }
        }
    }
});

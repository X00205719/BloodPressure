const chartCanvas = document.getElementById('myChart');
const systolicInput = document.getElementById("BP_Systolic");
const diastolicInput = document.getElementById("BP_Diastolic");

const bpStages = [
    { name: 'Low', xEnd: 59, yEnd: 89, color: '#E4C1F9' },
    { name: 'Ideal', xEnd: 79, yEnd: 119, color: '#68A691' },
    { name: 'Pre-High', xEnd: 89, yEnd: 139, color: '#C7EF00' },
    { name: 'High', xEnd: 100, yEnd: 190, color: '#FF5E5B' }
];

function drawBackgroundLayer(chart) {
    const { ctx, scales: { x, y } } = chart;

    bpStages.forEach(stage => {
        ctx.save();
        ctx.beginPath();
        ctx.globalCompositeOperation = 'destination-over';
        ctx.fillStyle = stage.color;
        ctx.moveTo(x.getPixelForValue(40), y.getPixelForValue(70));
        ctx.lineTo(x.getPixelForValue(stage.xEnd), y.getPixelForValue(70));
        ctx.lineTo(x.getPixelForValue(stage.xEnd), y.getPixelForValue(stage.yEnd));
        ctx.lineTo(x.getPixelForValue(40), y.getPixelForValue(stage.yEnd));
        ctx.closePath();
        ctx.fill();
        ctx.restore();
    });
}

function createChart() {
    const systolic = parseFloat(systolicInput.value);
    const diastolic = parseFloat(diastolicInput.value);

    const bgLayerPlugin = {
        id: 'bgLayer',
        beforeDatasetsDraw: chart => drawBackgroundLayer(chart)
    };

    new Chart(chartCanvas, {
        type: 'scatter',
        data: {
            datasets: [{
                label: 'Result',
                data: [{ x: diastolic, y: systolic }],
                borderWidth: 2,
                borderColor: '#FFF',
                backgroundColor: '#007FFF'
            }]
        },
        plugins: [bgLayerPlugin],
        options: {
            scales: {
                x: {
                    min: 40,
                    max: 100,
                    title: { display: true, text: 'Diastolic' }
                },
                y: {
                    min: 70,
                    max: 190,
                    title: { display: true, text: 'Systolic' }
                }
            }
        }
    });
}

createChart();